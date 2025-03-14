import { useState, useEffect } from 'react';
import axios from 'axios';
import RequireAuth from '../../components/RequireAuth';
import Header from './Homepage/Header';
import Footer from './Homepage/Footer';

interface DoctorType {
  id: number;
  name: string;
  description: string;
  hourlyRate: number;
}

export default function DoctorType() {
  const [doctorType, setDoctorType] = useState<DoctorType[]>([]);
  const [newType, setNewType] = useState<Omit<DoctorType, 'id'>>({
    name: '',
    description: '',
    hourlyRate: 0
  });
  const [isAdding, setIsAdding] = useState(false);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState('');

  // Load doctor types on component mount
  useEffect(() => {
    fetchDoctorType();
  }, []);

  const fetchDoctorType = async () => {
    setIsLoading(true);
    try {
      const response = await axios.get('http://localhost:5166/api/DoctorType');
      setDoctorType(response.data);
      setError('');
    } catch (err) {
      setError('Failed to load doctor types');
      console.error(err);
    } finally {
      setIsLoading(false);
    }
  };

  const handleAddType = async () => {
    try {
      const response = await axios.post('http://localhost:5166/api/DoctorType', newType);
      setDoctorType([...doctorType, response.data]);
      setNewType({ name: '', description: '', hourlyRate: 0 });
      setIsAdding(false);
      setError('');
    } catch (err) {
      setError('Failed to add doctor type');
      console.error(err);
    }
  };

  const handleDeleteType = async (id: number) => {
    if (confirm('Are you sure you want to delete this doctor type?')) {
      try {
        await axios.delete(`http://localhost:5166/api/DoctorType/${id}`);
        setDoctorType(doctorType.filter(type => type.id !== id));
        setError('');
      } catch (err) {
        setError('Failed to delete doctor type');
        console.error(err);
      }
    }
  };

  return (
    <RequireAuth>
        <div className="home">
            <Header />
            <div className="content-wrapper">
                <div className="p-6">
                    
                    <div className="flex justify-between items-center mb-6">
                    <h1 className="text-2xl font-semibold">Doctor Types</h1>
                    <button
                        onClick={() => setIsAdding(true)}
                        className="bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded"
                    >
                        Add New Type
                    </button>
                    </div>

                    {error && <div className="bg-red-100 text-red-700 p-3 mb-4 rounded">{error}</div>}

                    {isLoading ? (
                    <p>Loading doctor types...</p>
                    ) : (
                    <div className="overflow-x-auto">
                        <table className="min-w-full bg-white border border-gray-300">
                        <thead>
                            <tr className="bg-gray-100">
                            <th className="py-2 px-4 border-b text-left">Name</th>
                            <th className="py-2 px-4 border-b text-left">Description</th>
                            <th className="py-2 px-4 border-b text-right">Hourly Rate</th>
                            <th className="py-2 px-4 border-b text-center">Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            {doctorType.map(type => (
                            <tr key={type.id} className="hover:bg-gray-50">
                                <td className="py-2 px-4 border-b">{type.name}</td>
                                <td className="py-2 px-4 border-b">{type.description}</td>
                                <td className="py-2 px-4 border-b text-right">${type.hourlyRate.toFixed(2)}</td>
                                <td className="py-2 px-4 border-b text-center">
                                <button
                                    onClick={() => handleDeleteType(type.id)}
                                    className="text-red-500 hover:text-red-700"
                                >
                                    Delete
                                </button>
                                </td>
                            </tr>
                            ))}
                            {doctorType.length === 0 && (
                            <tr>
                                <td colSpan={4} className="py-4 text-center text-gray-500">
                                No doctor types found. Add one to get started.
                                </td>
                            </tr>
                            )}
                        </tbody>
                        </table>
                    </div>
                    )}

                    {isAdding && (
                    <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center p-4">
                        <div className="bg-white rounded-lg p-6 w-full max-w-md">
                        <h2 className="text-xl font-semibold mb-4">Add New Doctor Type</h2>
                        <div className="space-y-4">
                            <div>
                            <label className="block text-sm font-medium mb-1">Name</label>
                            <input
                                type="text"
                                value={newType.name}
                                onChange={(e) => setNewType({...newType, name: e.target.value})}
                                className="w-full p-2 border rounded"
                                placeholder="e.g., Pediatrician"
                            />
                            </div>
                            <div>
                            <label className="block text-sm font-medium mb-1">Description</label>
                            <textarea
                                value={newType.description}
                                onChange={(e) => setNewType({...newType, description: e.target.value})}
                                className="w-full p-2 border rounded"
                                placeholder="Description of this doctor type"
                                rows={3}
                            />
                            </div>
                            <div>
                            <label className="block text-sm font-medium mb-1">Hourly Rate ($)</label>
                            <input
                                type="number"
                                value={newType.hourlyRate}
                                onChange={(e) => setNewType({...newType, hourlyRate: parseFloat(e.target.value)})}
                                className="w-full p-2 border rounded"
                                min="0"
                                step="0.01"
                            />
                            </div>
                            <div className="flex justify-end space-x-2 pt-4">
                            <button
                                onClick={() => setIsAdding(false)}
                                className="px-4 py-2 border rounded text-gray-600 hover:bg-gray-100"
                            >
                                Cancel
                            </button>
                            <button
                                onClick={handleAddType}
                                className="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600"
                                disabled={!newType.name}
                            >
                                Save
                            </button>
                            </div>
                        </div>
                        </div>
                    </div>
                    )}
                </div>            
            </div>
            <Footer />
        </div>

    </RequireAuth>
  );
}